namespace MasterSpark.Engine
{
    public abstract class Scene
    {
        public string Name { get; }
        public SceneController Controller;

        public Scene(string name)
        {
            Name = name;
        }

        public virtual void Update()
        {
            
        }
        public virtual void Draw()
        {
            
        }
    }
}