using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Sora_Field
{
    public interface IReadSceneChaege
    {
        void Init(int _maxNum);
        void ChengeRightScene();
        void ChengeLeftScene();
        IObservable<int> GetNextScene();
    }
    public class SceneChenge : IReadSceneChaege
    {
        private static int nowSceneNam = 1;
        private static int maxScene;

        private Subject<int> nextScene = new();

        public void Init(int _maxNum)
        {
            maxScene = _maxNum;
            nextScene.OnNext(nowSceneNam);
        }

        public void ChengeRightScene()
        {
            if (nowSceneNam == maxScene)
            {
                nowSceneNam = 1;
            }
            else
            {
                nowSceneNam++;
            }
            nextScene.OnNext(nowSceneNam);
        }

        public void ChengeLeftScene()
        {
            if (nowSceneNam == 1)
            {
                nowSceneNam = maxScene;
            }
            else
            {
                nowSceneNam--;
            }
            nextScene.OnNext(nowSceneNam);
        }

        public IObservable<int> GetNextScene()
        {
            return nextScene;
        }
    }
}