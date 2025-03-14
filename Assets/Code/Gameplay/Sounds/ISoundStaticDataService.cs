namespace Code.Gameplay.Sounds
{
    public interface ISoundStaticDataService
    {
        Sound GetEffect(SoundTypeId soundTypeId);
    }
}