using Character;
using Manager;
using SaveData;
using SV;
using SV.Chara;
using System;
using System.Collections.Generic;

namespace SVS_CustomTraits
{
    internal class CustomLogicConditions
    {
        private static Random _rnd = new();
        public static class TraitSibling
        {
            public static float SetAnswer(YesNoJudgeManager.AnswerInfo answerInfo, YesNoJudgeManager.YesNoInfo yesNoInfo, int commandID, int questionCount, float answerRate)
            {
                Actor chara = yesNoInfo.active;
                Actor targetChara = yesNoInfo.passive;

                float rate = answerRate;

                if ((chara.gameParameter.individuality.answer.Contains(40) && targetChara.gameParameter.individuality.answer.Contains(40)) && chara.lastname == targetChara.lastname)
                {
                    int chastity = chara.gameParameter.LvChastity;

                    switch (commandID)
                    {
                        case 0://Daily talk
                            return rate *= 1.1f;
                        case 1://Romantic talk
                            return rate *= 0.98f;
                        case 2://Lewd talk
                            return rate *= 0.95f;
                        case 33://Kiss
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.7f;
                                case 4://Highest Virtue.
                                    return rate *= 0.5f;
                            }
                            break;
                        case 34://Touch
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.7f;
                                case 4://Highest Virtue.
                                    return rate *= 0.5f;
                            }
                            break;
                        case 35://Sex
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.7f;
                                case 4://Highest Virtue.
                                    return rate *= 0.5f;
                            }
                            break;
                        case 37:
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.8f;
                                case 4://Highest Virtue.
                                    return rate *= 0.7f;
                            }
                            break;
                        case 77:
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.8f;
                                case 4://Highest Virtue.
                                    return rate *= 0.7f;
                            }
                            break;
                    }
                }

                return answerInfo.rate;
            }
            public static void SetFavorabiltyGain(FavourableImpressionManager favourable, HumanData _myCharaData, CharactersGameParameter _myGameParam, HumanData _targetCharaData, CharactersGameParameter _targetGameParam)
            {
                float loveRate = 0;
                float friendRate = 0;
                float distantRate = 0;
                float hateRate = 0;

                //Edit the values here. Examples below.
                if (_myCharaData.GameParameter.individuality.answer.Contains(40) && _targetCharaData.GameParameter.individuality.answer.Contains(40))
                {
                    if (Game.Charas.ContainsKey(_myGameParam.Index) && Game.Charas.ContainsKey(_targetGameParam.Index))
                    {
                        Actor chara = Game.Charas[_myGameParam.Index];
                        Actor targetChara = Game.Charas[_targetGameParam.Index];
                        if ((chara.lastname == targetChara.lastname))
                        {
                            //Love has a -10% gain
                            loveRate = -0.1f;
                            //friend has 10% gain.
                            friendRate = 0.1f;
                            //distant has -50% gain.
                            distantRate = -0.5f;
                            //hate has a -20% gain.
                            hateRate = -0.2f;
                        }
                    }
                }
                
                //Apply the new rates below.
                //Love points rate gain.
                favourable.addRates[0] += loveRate;
                //Friend points rate gain.
                favourable.addRates[1] += friendRate;
                //Distant points rate gain.
                favourable.addRates[2] += distantRate;
                //Hate points rate gain.
                favourable.addRates[3] += hateRate;
            }
        }
        public static class TraitParent
        {
            public static float SetAnswer(YesNoJudgeManager.AnswerInfo answerInfo, YesNoJudgeManager.YesNoInfo yesNoInfo, int commandID, int questionCount, float answerRate)
            {
                Actor chara = yesNoInfo.active;
                Actor targetChara = yesNoInfo.passive;

                float rate = answerRate;

                if ((chara.gameParameter.individuality.answer.Contains(42) && targetChara.gameParameter.individuality.answer.Contains(41)) && chara.lastname == targetChara.lastname)
                {
                    int chastity = chara.gameParameter.LvChastity;

                    switch (commandID)
                    {
                        case 0://Daily talk
                            return rate *= 1.1f;
                        case 1://Romantic talk
                            return rate *= 0.98f;
                        case 2://Lewd talk
                            return rate *= 0.95f;
                        case 33://Kiss
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.7f;
                                case 4://Highest Virtue.
                                    return rate *= 0.5f;
                            }
                            break;
                        case 34://Touch
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.7f;
                                case 4://Highest Virtue.
                                    return rate *= 0.5f;
                            }
                            break;
                        case 35://Sex
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.7f;
                                case 4://Highest Virtue.
                                    return rate *= 0.5f;
                            }
                            break;
                        case 37:
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.8f;
                                case 4://Highest Virtue.
                                    return rate *= 0.7f;
                            }
                            break;
                        case 77:
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.8f;
                                case 4://Highest Virtue.
                                    return rate *= 0.7f;
                            }
                            break;
                    }
                }

                return answerInfo.rate;
            }
            public static void SetFavorabiltyGain(FavourableImpressionManager favourable, HumanData _myCharaData, CharactersGameParameter _myGameParam, HumanData _targetCharaData, CharactersGameParameter _targetGameParam)
            {
                float loveRate = 0;
                float friendRate = 0;
                float distantRate = 0;
                float hateRate = 0;

                //Edit the values here. Examples below.
                if (_myCharaData.GameParameter.individuality.answer.Contains(42) && _targetCharaData.GameParameter.individuality.answer.Contains(41))
                {
                    if (Game.Charas.ContainsKey(_myGameParam.Index) && Game.Charas.ContainsKey(_targetGameParam.Index))
                    {
                        Actor chara = Game.Charas[_myGameParam.Index];
                        Actor targetChara = Game.Charas[_targetGameParam.Index];
                        if ((chara.lastname == targetChara.lastname))
                        {
                            //Love has a -10% gain
                            loveRate = -0.1f;
                            //friend has 10% gain.
                            friendRate = 0.1f;
                            //distant has -50% gain.
                            distantRate = -0.5f;
                            //hate has a -20% gain.
                            hateRate = -0.2f;
                        }
                    }
                }

                //Apply the new rates below.
                //Love points rate gain.
                favourable.addRates[0] += loveRate;
                //Friend points rate gain.
                favourable.addRates[1] += friendRate;
                //Distant points rate gain.
                favourable.addRates[2] += distantRate;
                //Hate points rate gain.
                favourable.addRates[3] += hateRate;
            }
        }
        public static class TraitSonDaughter
        {
            public static float SetAnswer(YesNoJudgeManager.AnswerInfo answerInfo, YesNoJudgeManager.YesNoInfo yesNoInfo, int commandID, int questionCount, float answerRate)
            {
                Actor chara = yesNoInfo.active;
                Actor targetChara = yesNoInfo.passive;

                float rate = answerRate;

                if ((chara.gameParameter.individuality.answer.Contains(41) && targetChara.gameParameter.individuality.answer.Contains(42)) && chara.lastname == targetChara.lastname)
                {
                    int chastity = chara.gameParameter.LvChastity;

                    switch (commandID)
                    {
                        case 0://Daily talk
                            return rate *= 1.1f;
                        case 1://Romantic talk
                            return rate *= 0.98f;
                        case 2://Lewd talk
                            return rate *= 0.95f;
                        case 33://Kiss
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.7f;
                                case 4://Highest Virtue.
                                    return rate *= 0.5f;
                            }
                            break;
                        case 34://Touch
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.7f;
                                case 4://Highest Virtue.
                                    return rate *= 0.5f;
                            }
                            break;
                        case 35://Sex
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.7f;
                                case 4://Highest Virtue.
                                    return rate *= 0.5f;
                            }
                            break;
                        case 37:
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.8f;
                                case 4://Highest Virtue.
                                    return rate *= 0.7f;
                            }
                            break;
                        case 77:
                            switch (chastity)
                            {
                                case 2://Normal Virtue.
                                    return rate *= 0.9f;
                                case 3://High Virtue.
                                    return rate *= 0.8f;
                                case 4://Highest Virtue.
                                    return rate *= 0.7f;
                            }
                            break;
                    }
                }

                return answerInfo.rate;
            }
            public static void SetFavorabiltyGain(FavourableImpressionManager favourable, HumanData _myCharaData, CharactersGameParameter _myGameParam, HumanData _targetCharaData, CharactersGameParameter _targetGameParam)
            {
                float loveRate = 0;
                float friendRate = 0;
                float distantRate = 0;
                float hateRate = 0;

                //Edit the values here. Examples below.
                if (_myCharaData.GameParameter.individuality.answer.Contains(42) && _targetCharaData.GameParameter.individuality.answer.Contains(41))
                {
                    if (Game.Charas.ContainsKey(_myGameParam.Index) && Game.Charas.ContainsKey(_targetGameParam.Index))
                    {
                        Actor chara = Game.Charas[_myGameParam.Index];
                        Actor targetChara = Game.Charas[_targetGameParam.Index];
                        if ((chara.lastname == targetChara.lastname))
                        {
                            //Love has a -10% gain
                            loveRate = -0.1f;
                            //friend has 10% gain.
                            friendRate = 0.1f;
                            //distant has -50% gain.
                            distantRate = -0.5f;
                            //hate has a -20% gain.
                            hateRate = -0.2f;
                        }
                    }
                }

                //Apply the new rates below.
                //Love points rate gain.
                favourable.addRates[0] += loveRate;
                //Friend points rate gain.
                favourable.addRates[1] += friendRate;
                //Distant points rate gain.
                favourable.addRates[2] += distantRate;
                //Hate points rate gain.
                favourable.addRates[3] += hateRate;
            }
        }
        public static class TraitStalker
        {
            public static void SetAction(SVThinking thinking)
            {
                if (thinking.CharaCtrl.IsPC) return;//Action is only for NPC.

                //Get character Actor.
                Actor chara = thinking.CharaCtrl.AI.charaData;
                //Get character BehaviourController.
                BehaviourController charaBC = thinking.CharaCtrl;

                //Stalking Logic
                //Check if the character action is a map action.
                if (charaBC.target.kind == BehaviourController.TargetInfo.TargetKind.Map)
                {

                    if (chara.charasGameParam.commandNo > -1) return;
                    //Checks that the map action is set as nothing (-1) and checks if there is a character they like.
                    if (charaBC.target.job == -1 && chara.charasGameParam.sensitivity.tableHighFavorability[0].Count > 0)
                    {
                        //Get the ID of the Target Character.
                        int targetCharaID = chara.charasGameParam.sensitivity.tableHighFavorability[0][0];

                        //Checks if the Target Character exist.
                        if (Game.Charas.ContainsKey(targetCharaID))
                        {
                            //Checks if the Target Character is loaded in the game (Not hidden in the character roster).
                            if (Game.Charas[targetCharaID].charaBase is not null)
                            {
                                //Gets Target Character BehaviourController.
                                var targetBC = Game.Charas[targetCharaID].charaBase.BehaviourCtrl;
                                //Get the ID of the map where the Target Character currently is.
                                int targetMapID = targetBC.nowMapID;
                                //Checks if the targetMapID is a valid map.
                                if (MapManager.Instance.MapListTable.ContainsKey(targetMapID))
                                {
                                    //checks if the map is not a private room.
                                    if (MapManager.Instance.MapListTable[targetMapID].Kind != 1)
                                    {
                                        //Checks if the stalking characters is not in the same map as the target character.
                                        if (charaBC.nowMapID != targetMapID)
                                        {
                                            //Checks if the targetMapID has map points.
                                            if (MapManager.Instance.pointInfoTable.ContainsKey(targetMapID))
                                            {
                                                //Checks if the targetMapID has actions points for action -1 (nothing)
                                                if (MapManager.Instance.PointInfoTable[targetMapID].pointList.urouroTable.ContainsKey(-1))
                                                {
                                                    //Get a list of the map points.
                                                    var mapPoints = MapManager.Instance.PointInfoTable[targetMapID].pointList.urouroTable[-1].randoms;
                                                    
                                                    //Picks a random map point to do the action.
                                                    int newPoint = _rnd.Next(0, mapPoints.Count);

                                                    //Now we set the map action to be on the same map as the target.
                                                    charaBC.target.SetMap(mapPoints[newPoint], targetMapID, 0, -1);
                                                }
                                            }
                                        }
                                    }
                                }                        
                            }                          
                        }
                    }
                }
            }
        }
        public static class TraitLazy
        {
            public static float SetAnswer(YesNoJudgeManager.AnswerInfo answerInfo, YesNoJudgeManager.YesNoInfo yesNoInfo, int commandID, int questionCount, float answerRate)
            {
                //Answer Rate in porcentage.
                float rate = answerRate;
                //Character that is answering the action.
                Actor chara = yesNoInfo.passive;
                if (chara.gameParameter.individuality.answer.Contains(42))
                {
                    //Command List
                    switch (commandID)
                    {
                        case 23:
                            return rate *= 0.5f;
                        case 24:
                            return rate *= 0.5f;
                        case 25:
                            return rate *= 0.5f;
                        case 36:
                            return rate *= 0.5f;
                        case 41:
                            return rate *= 0.5f;
                        case 42:
                            return rate *= 0.5f;
                        case 43:
                            return rate *= 0.5f;
                    }
                }
                //Return unmodify rate.
                return rate;
            }
            public static int SetReaction(AI charaAI, AI charaAI_2, AI charaAI_3, int no, int reactionNo)
            {
                //no is the value of what the character is reacting to.
                switch (no)
                {
                    case 0://Reacting to nothing.
                        break;
                    case 1://Reactiong to public sex.
                        break;
                    case 2://Reactiong to masturbation.
                        break;
                    case 5://Reacting to fights.
                        break;
                    case 6://Skinship (contact between characters) like hug, kissing and grope.
                        break;
                    case 7://Reacting to character interacting with each other. 
                        break;
                    case 8://Need confirmation, but it may be for when the character loses a scramble. React to losing maybe?
                        break;
                    case 9://Unkown, maybe for opposite sex reactions in male/female rooms.
                        break;
                    case 10://Unknown, H related, maybe 3P.
                        break;
                }

                //The return value depends on what the character is reacting to
                return reactionNo;
            }
            /// <summary>
            /// Set the type of action for the character
            /// </summary>
            /// <param name="thinking"></param>
            public static void SetAction(SVThinking thinking)
            {
                if (thinking.CharaCtrl.IsPC) return;//Action is only for NPC. 

                //Get character Actor.
                Actor chara = thinking.CharaCtrl.AI.charaData;
                //Get character BehaviourController.
                BehaviourController charaBC = thinking.CharaCtrl;
                
                //The character will go to the shrine when it has nothing to do.
                //Check if the character action is a map action.
                if (charaBC.target.kind == BehaviourController.TargetInfo.TargetKind.Map && chara.charasGameParam.commandNo < 0 && charaBC.target.type == 0)
                {
                    //Map ID;
                    int mapID = charaBC.target.id;
                    //Checks that the map action is set as nothing (-1).
                    if (charaBC.target.job != -1)
                    {
                        var lazyChance = _rnd.Next(0,100);
                        if (lazyChance < 30) return;
                        //Checks if the map exist
                        if (MapManager.Instance.MapListTable.ContainsKey(mapID))
                        {
                            //checks if the map is not a private room.
                            if (MapManager.Instance.MapListTable[mapID].Kind != 1)
                            {
                                //Checks if the newMapID has map points.
                                if (MapManager.Instance.pointInfoTable.ContainsKey(mapID))
                                {
                                    //Checks if the newMapID has actions points for action -1 (nothing)
                                    if (MapManager.Instance.PointInfoTable[mapID].pointList.urouroTable.ContainsKey(-1))
                                    {
                                        //Get a list of the map points.
                                        var mapPoints = MapManager.Instance.PointInfoTable[mapID].pointList.urouroTable[-1].randoms;

                                        //Picks a random map point to do the action.
                                        int newPoint = _rnd.Next(0, mapPoints.Count);

                                        //Now we set the map action to be on the same map as the target.
                                        charaBC.target.SetMap(mapPoints[newPoint], mapID, 0, -1);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static class TraitTemplate
        {
            /// <summary>
            /// Set the answer type during interactions.
            /// <paramref name="answerInfo"/> has the answer type and rate. <paramref name="yesNoInfo"/> has the characters information. 
            /// </summary>
            /// <param name="answerInfo"></param>
            /// <param name="yesNoInfo"></param>
            /// <param name="commandID"></param>
            /// <param name="questionCount"></param>
            public static float SetAnswer(YesNoJudgeManager.AnswerInfo answerInfo, YesNoJudgeManager.YesNoInfo yesNoInfo, int commandID, int questionCount, float answerRate)
            {
                //Type of answer: 0 for Yes, 1 for No, 2 ambiguous/what? (used by Oblivious trait)
                int answerType = answerInfo.ans;

                //Answer Rate in porcentage.
                float rate = answerRate;

                //Character that is doing the action.
                Actor chara = yesNoInfo.active;

                //Character that is answering the action.
                Actor targetChara = yesNoInfo.passive;

                //Command List
                switch (commandID)
                {
                    case 35://Sex
                        return rate * 2;
                }

                //Return unmodify rate.
                return rate;
            }
            /// <summary>
            /// Interruption type the character will do. returns the ID of the reaction. <paramref name="reactionNo"/> is the current reaction
            /// </summary>
            /// <param name="charaAI"></param>
            /// <param name="charaAI_2"></param>
            /// <param name="charaAI_3"></param>
            /// <param name="no"></param>
            /// <param name="reactionNo"></param>
            /// <returns></returns>
            public static int SetReaction(AI charaAI, AI charaAI_2, AI charaAI_3, int no, int reactionNo)
            {
                //no is the value of what the character is reacting to.
                switch (no)
                {
                    case 0://Reacting to nothing.
                        break;
                    case 1://Reactiong to public sex.
                        break;
                    case 2://Reactiong to masturbation.
                        break;
                    case 5://Reacting to fights.
                        break;
                    case 6://Skinship (contact between characters) like hug, kissing and grope.
                        break;
                    case 7://Reacting to character interacting with each other. 
                        break;
                    case 8://Need confirmation, but it may be for when the character loses a scramble. React to losing maybe?
                        break;
                    case 9://Unkown, maybe for opposite sex reactions in male/female rooms.
                        break;
                    case 10://Unknown, H related, maybe 3P.
                        break;
                }

                //The return value depends on what the character is reacting to
                return reactionNo;
            }
            /// <summary>
            /// Set the type of action for the character
            /// </summary>
            /// <param name="thinking"></param>
            public static void SetAction(SVThinking thinking)
            {
                if (thinking.CharaCtrl.IsPC) return;//Action is only for NPC. 

                //Get character Actor.
                Actor chara = thinking.CharaCtrl.AI.charaData;
                //Get character BehaviourController.
                BehaviourController charaBC = thinking.CharaCtrl;

                //The character will go to the shrine when it has nothing to do.
                //Check if the character action is a map action.
                if (charaBC.target.kind == BehaviourController.TargetInfo.TargetKind.Map)
                {
                    //Map ID; 6 is Shrine
                    int newMapID = 6;
                    //Checks that the map action is set as nothing (-1).
                    if (charaBC.target.job == -1)
                    {
                        //Checks if the map exist
                        if (MapManager.Instance.MapListTable.ContainsKey(newMapID))
                        {
                            //checks if the map is not a private room.
                            if (MapManager.Instance.MapListTable[newMapID].Kind != 1)
                            {
                                //Checks if the character is not in the same map.
                                if (charaBC.nowMapID != newMapID)
                                {
                                    //Checks if the newMapID has map points.
                                    if (MapManager.Instance.pointInfoTable.ContainsKey(newMapID))
                                    {
                                        //Checks if the newMapID has actions points for action -1 (nothing)
                                        if (MapManager.Instance.PointInfoTable[newMapID].pointList.urouroTable.ContainsKey(-1))
                                        {
                                            //Get a list of the map points.
                                            var mapPoints = MapManager.Instance.PointInfoTable[newMapID].pointList.urouroTable[-1].randoms;

                                            //Picks a random map point to do the action.
                                            int newPoint = _rnd.Next(0, mapPoints.Count);

                                            //Now we set the map action to be on the same map as the target.
                                            charaBC.target.SetMap(mapPoints[newPoint], newMapID, 0, -1);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            public static void SetFavorabiltyGain(FavourableImpressionManager favourable, bool _isActive, bool _isOneWay, HumanData _myCharaData, CharactersGameParameter _myGameParam, HumanData _targetCharaData, CharactersGameParameter _targetGameParam)
            {
                float loveRate = 0;
                float friendRate = 0;
                float distantRate = 0;
                float hateRate = 0;

                //Edit the values here. Examples below.
                //Love has a 10% gain
                loveRate = 0.1f;
                //friend has -10% gain.
                friendRate = -0.1f;
                //distant has no modificable gain.
                distantRate = 0;
                //hate has a 50% gain.
                hateRate = 0.5f;

                //Apply the new rates below.
                //Love points rate gain.
                favourable.addRates[0] += loveRate;
                //Friend points rate gain.
                favourable.addRates[1] += friendRate;
                //Distant points rate gain.
                favourable.addRates[2] += distantRate;
                //Hate points rate gain.
                favourable.addRates[3] += hateRate;
            }
        }
        public static class TraitTest
        {
            /// <summary>
            /// Set the answer type during interactions.
            /// <paramref name="answerInfo"/> has the answer type and rate. <paramref name="yesNoInfo"/> has the characters information. 
            /// </summary>
            /// <param name="answerInfo"></param>
            /// <param name="yesNoInfo"></param>
            /// <param name="commandID"></param>
            /// <param name="questionCount"></param>
            public static float SetAnswer(YesNoJudgeManager.AnswerInfo answerInfo, YesNoJudgeManager.YesNoInfo yesNoInfo, int commandID, int questionCount, float answerRate)
            {
                //Type of answer: 0 for Yes, 1 for No, 2 ambiguous/what? (used by Oblivious trait)
                int answerType = answerInfo.ans;

                //Answer Rate in porcentage.
                float rate = answerRate;

                //Character that is doing the action.
                Actor chara = yesNoInfo.active;

                //Character that is answering the action.
                Actor targetChara = yesNoInfo.passive;

                //Command List
                switch (commandID)
                {
                    case 36://Follow me
                        return rate * 0;
                    case 38://Wait on this map later
                        return rate * 0;
                }

                //Return unmodify rate.
                return rate;
            }         
            /// <summary>
            /// Set the type of action for the character
            /// </summary>
            /// <param name="thinking"></param>
            public static void SetAction(SVThinking thinking)
            {
                if (thinking.CharaCtrl.IsPC) return;//Action is only for NPC. 

                //Get character Actor.
                Actor chara = thinking.CharaCtrl.AI.charaData;
                //Get character BehaviourController.
                BehaviourController charaBC = thinking.CharaCtrl;

                if (charaBC.target.kind == BehaviourController.TargetInfo.TargetKind.Chara)
                {
                    if (chara.charasGameParam.commandNo > -1 && Game.Charas.ContainsKey(charaBC.target.id))
                    {
                        var targetChara = Game.Charas[charaBC.target.id];
                        if (targetChara.charaBase is not null)
                        {
                            if (targetChara.charaBase.BehaviourCtrl.nowMapID == 6) return;
                            thinking.isSuccess = false;
                            chara.charasGameParam.commandNo = -1;
                            charaBC.target.Clear();
                            charaBC.targetBehaviourCtrl = null;
                            charaBC.target.kind = BehaviourController.TargetInfo.TargetKind.Map;
                            charaBC.BaseAction = BehaviourController.BaseActionKind.Personal;                          
                        }
                    }                
                }
                //The character will go to the shrine when it has nothing to do.
                //Check if the character action is a map action.
                if (charaBC.target.kind == BehaviourController.TargetInfo.TargetKind.Map)
                {
                    //Map ID; 6 is Shrine
                    int newMapID = 6;
                    //Checks that the map action is set as nothing (-1).
                    //Checks if the map exist
                    if (MapManager.Instance.MapListTable.ContainsKey(newMapID))
                    {
                        //checks if the map is not a private room.
                        if (MapManager.Instance.MapListTable[newMapID].Kind != 1)
                        {
                            //Checks if the newMapID has map points.
                            if (MapManager.Instance.pointInfoTable.ContainsKey(newMapID))
                            {
                                //Checks if the newMapID has actions points for action -1 (nothing)
                                if (MapManager.Instance.PointInfoTable[newMapID].pointList.urouroTable.ContainsKey(-1))
                                {
                                    //Get a list of the map points.
                                    var mapPoints = MapManager.Instance.PointInfoTable[newMapID].pointList.urouroTable[-1].randoms;

                                    //Picks a random map point to do the action.
                                    int newPoint = _rnd.Next(0, mapPoints.Count);

                                    //Now we set the map action to be on the same map as the target.
                                    charaBC.target.SetMap(mapPoints[newPoint], newMapID, 0, -1);
                                }
                            }
                        }
                    }
                }
            }
            public static void SetFavorabiltyGain(FavourableImpressionManager favourable, bool _isActive, bool _isOneWay, HumanData _myCharaData, CharactersGameParameter _myGameParam, HumanData _targetCharaData, CharactersGameParameter _targetGameParam)
            {
                float loveRate = 0;
                float friendRate = 0;
                float distantRate = 0;
                float hateRate = 0;

                //Edit the values here. Examples below.
                //Love has a 10% gain
                loveRate = 0.1f;
                //friend has -10% gain.
                friendRate = -0.1f;
                //distant has no modificable gain.
                distantRate = 0;
                //hate has a 50% gain.
                hateRate = 0.5f;

                //Apply the new rates below.
                //Love points rate gain.
                favourable.addRates[0] += loveRate;
                //Friend points rate gain.
                favourable.addRates[1] += friendRate;
                //Distant points rate gain.
                favourable.addRates[2] += distantRate;
                //Hate points rate gain.
                favourable.addRates[3] += hateRate;
            }
        }
        
    }
}
