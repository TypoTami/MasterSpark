using System.Collections.Generic;

namespace MasterSpark.Engine
{
    public class SceneController
    {
        private List<Scene> _sceneList;
        private int _currentScene;

        public SceneController()
        {
            _sceneList = new List<Scene>();
            _currentScene = 0;
        }

        // TODO: Make it so when adding a scene, dont load all of is resources when it is not being used.
        // This could be done by having a seperate Init() from the constructor or somehow constructing and 
        // deconstructing our scenes.
        // List of actions for constructions and deconstructions?
        public void AddScene(Scene newScene)
        {
            _sceneList.Add(newScene);
        }

        public void LoadScene(string name)
        {
            _currentScene = 0;
            
            while (_sceneList[_currentScene].Name != name)
            {
                _currentScene++;
            }

            _sceneList[_currentScene].Controller = this;
        }

        public Scene Current()
        {
            return _sceneList[_currentScene];
        }
    }
}