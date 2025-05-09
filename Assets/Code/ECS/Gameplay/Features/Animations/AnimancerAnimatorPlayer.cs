using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Animancer;
using Code.ECS.Gameplay.Features.Animations.Enums;
using Cysharp.Threading.Tasks;
using UniRx;
using Object = UnityEngine.Object;

namespace Code.ECS.Gameplay.Features.Animations
{
    public class AnimancerAnimatorPlayer : SerializedMonoBehaviour
    {
        [SerializeField,FolderPath] private string _animationsFolderPath;
        
        [OdinSerialize] private Dictionary<AnimationTypeId, ClipTransition> _animationClips;
        [SerializeField] private AnimancerComponent _animancer;
        
        private readonly Dictionary<AnimationTypeId, AnimancerState> _animationStates = new();

        private readonly Subject<AnimationTypeId> _animationRequested = new();
        
        public AnimationTypeId LastPlayingAnimation { get; private set; }

        private void Awake()
        {
            FillAnimationStates();
        }

        public bool IsPlaying(AnimationTypeId animationTypeId)
        {
            if (!_animationStates.ContainsKey(animationTypeId))
                return false;

            AnimancerState state = _animationStates[animationTypeId];
            
            return state.IsPlayingAndNotEnding();
        }
        
        public AnimancerState GetState(AnimationTypeId animationTypeId) =>
            _animationStates.GetValueOrDefault(animationTypeId);
        
        public async UniTask StartAnimation(AnimationTypeId animationTypeId,
            float fadeDuration = 0.2f, FadeMode fadeMode = FadeMode.FixedSpeed)
        {
            Debug.Log($"@@@ anim type start - {animationTypeId}");
            if (!_animationClips.TryGetValue(animationTypeId, out var clip))
                throw new Exception($"no animation for {animationTypeId}");

            ReportAnimationRequested(animationTypeId);
            
            AnimancerState state = _animancer.Play(clip, fadeDuration, fadeMode);

            _animationStates[animationTypeId] = state;
            
            LastPlayingAnimation = animationTypeId;

            await state;
        }

        private void FillAnimationStates()
        {
            foreach (var animationType in _animationClips.Keys)
            {
                if (_animationClips.TryGetValue(animationType, out var clip))
                {
                    AnimancerState state = _animancer.States.GetOrCreate(clip);
                    _animationStates[animationType] = state;
                }
            }
        }

        private void ReportAnimationRequested(AnimationTypeId animationTypeId)
        {
            _animationRequested?.OnNext(animationTypeId);
        }
        
         [Button("Update Animations From Folder")]
        private void UpdateAnimationsFromFolder()
        {
            if (string.IsNullOrEmpty(_animationsFolderPath))
            {
                Debug.LogError("Animation folder path is not set!");
                return;
            }

            _animationClips.Clear();

            // Получаем все FBX файлы в указанной папке и подпапках
            string[] fbxFiles = Directory.GetFiles(_animationsFolderPath, "*.fbx", SearchOption.AllDirectories);

            foreach (string fbxPath in fbxFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(fbxPath).ToLower();

                // Проверяем все значения enum
                foreach (AnimationTypeId animationType in System.Enum.GetValues(typeof(AnimationTypeId)))
                {
                    // Пропускаем None
                    if (animationType == AnimationTypeId.None)
                        continue;

                    string enumName = animationType.ToString().ToLower();

                    // Если имя файла содержит название анимации
                    if (fileName.Contains(enumName))
                    {
                        // Загружаем все анимации из FBX
                        Object[] assets = AssetDatabase.LoadAllAssetsAtPath(fbxPath);
                        
                        foreach (Object asset in assets)
                        {
                            if (asset is AnimationClip clip)
                            {
                                // Если это основная анимация или единственная в файле
                                if (asset.name.ToLower().Equals(enumName) || assets.Count(a => a is AnimationClip) == 1)
                                {
                                    if (!_animationClips.ContainsKey(animationType))
                                    {
                                        float speed = 1f;

                                        if (animationType == AnimationTypeId.Hide || animationType == AnimationTypeId.Get)
                                            speed = 2.5f;
                                            
                                        var transition = new ClipTransition
                                        {
                                            Clip = clip,
                                            Speed = speed,
                                            NormalizedStartTime = Single.NaN,
                                            FadeDuration = 0.25f 
                                        };
                                        
                                        _animationClips.Add(animationType, transition);
                                        Debug.Log($"Added animation: {animationType} from {fbxPath}");
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"Animation {animationType} already exists in database!");
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
    }
}