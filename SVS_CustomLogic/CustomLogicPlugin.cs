using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using Character;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using SaveData;
using SV;
using SV.Chara;
using SV.Title;

namespace SVS_CustomTraits
{
    [BepInPlugin(GUID, DisplayName, Version)]
    public class CustomLogicPlugin : BasePlugin
    {
        public const string DisplayName = "SVS_Custom_Logic";
        public const string GUID = "DS27.SVS.CustomLogic";
        public const string Version = "0.1.0";

        internal static new ManualLogSource Log;
        private static Harmony patchedHooks;

        private static ConfigEntry<bool> _showLog;


        public override void Load()
        {
            // Plugin startup logic
            Log = base.Log;

            _showLog = Config.Bind("Log", "Show Log", true, new ConfigDescription("For debugging", null));

            patchedHooks = Harmony.CreateAndPatchAll(typeof(Hooks));
        }
        public override bool Unload()
        {
            patchedHooks?.UnpatchSelf();
            return true;
        }
        public static bool GetShowLog()
        {
            return _showLog.Value;
        }
        internal static class Hooks
        {
            //Load at tittle screen
            [HarmonyPostfix]
            [HarmonyPatch(typeof(TitleScene), nameof(TitleScene.Start))]
            public static void LoadCustomLogicAtTittleScreen(SimulationScene __instance)
            {
                CustomLogic.AddTrait();
            }

            //Set Custom Favor Rates
            [HarmonyPriority(500)]
            [HarmonyPrefix]
            [HarmonyPatch(typeof(FavourableImpressionManager), nameof(FavourableImpressionManager.IndividualityCorrection))]
            public static void CustomLogicFavorRates(FavourableImpressionManager __instance, bool _isActive, bool _isOneWay, HumanData _myCharaData, CharactersGameParameter _myGameParam, HumanData _targetCharaData, CharactersGameParameter _targetGameParam)
            {
                CustomLogic.CustomLogicFavorabiltyGain(__instance, _isActive, _isOneWay, _myCharaData, _myGameParam, _targetCharaData, _targetGameParam);
            }

            //Set Reaction/Interruption
            [HarmonyPriority(500)]
            [HarmonyPostfix]
            [HarmonyPatch(typeof(ReactionManager), nameof(ReactionManager.Confirmation))]
            public static int CustomLogicReaction(int __result, AI _ai, AI _ai1, AI _ai2, int no)
            {
                return CustomLogic.CustomLogicReaction(_ai, _ai1, _ai2, no, __result);
            }

            //Set Target Character
            [HarmonyPriority(500)]
            [HarmonyPostfix]
            [HarmonyPatch(typeof(ThinkingManager), nameof(ThinkingManager.InterpersonalCommandSelectionTarget))]
            public static int SetTarget(int __result, Actor _actor, int _commandID)
            {
                return __result;
            }

            //Set Character Actions
            [HarmonyPriority(500)]
            [HarmonyPostfix]
            [HarmonyPatch(typeof(SVThinking), nameof(SVThinking.OnUpdate))]
            public static void CustomLogicAction(SVThinking __instance)
            {
                CustomLogic.CustomLogicAction(__instance);
            }

            //Set Action success Rate 
            [HarmonyPriority(500)]
            [HarmonyPostfix]
            [HarmonyPatch(typeof(BaseAnswer), nameof(BaseAnswer.Judge))]
            public static void CustomLogicAnswerRate(bool __result, YesNoJudgeManager.AnswerInfo _ansInfo, YesNoJudgeManager.YesNoInfo _ynInfo, int _commandID, int _questionCount, Il2CppStructArray<bool> _calcs)
            {
                if (__result) CustomLogic.CustomLogicAnswerRate(_ansInfo, _ynInfo, _commandID, _questionCount);
            }
        }
    }
}
