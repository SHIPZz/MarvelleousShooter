using System;
using DG.Tweening;

namespace Code.Extensions
{
  public static class NumericExtensions
  {
    public static float ZeroIfNegative(this float value) => value >= 0 ? value : 0;

    public static int ZeroIfNegative(this int value) => value >= 0 ? value : 0;

    public static float MoveQuicklyTo(this float value, float target = 0, float duration = 0.2f, Action onComplete = null)
    {
       DOTween.To(() => value,
           x => value = x,
           target, duration)
         .OnComplete(() => onComplete?.Invoke());

       return value;
    }
  }
}