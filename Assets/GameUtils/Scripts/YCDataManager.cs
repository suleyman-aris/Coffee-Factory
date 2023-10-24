using System;
using System.Collections.Generic;
using UnityEngine;

namespace YsoCorp {
    namespace GameUtils {

        [DefaultExecutionOrder(-15)]
        public class YCDataManager : ADataManager {
            private static string PLAYER_LAUNCH_COUNT = "YC_PLAYER_LAUNCH_COUNT";
            private static string PLAYER_GAME_COUNT = "YC_PLAYER_GAME_COUNT";

            private static string ADVERTISING_ID = "ADVERTISING_ID";
            private static string IOS_CONSENT_SHOWN = "IOS_CONSENT_SHOWN";
            private static string ADSSHOW = "ADSSHOW";
            private static string AB_PLAYER_SAMPLE = "YC_PLAYER_SAMPLE";
            private static string REDROCK_REVENUE = "REDROCK_REVENUE";
            private static string LANGUAGE = "LANGUAGE";

            private static string GDPR_ADS = "GDPR_ADS";
            private static string GDPR_ANALYTICS = "GDPR_ANALYTICS";
            private static string INTERSTITIALS_NB = "INTERSTITIALS_NB";
            private static string REWARDEDS_NB = "REWARDEDS_NB";
            private static string TIMESTAMP = "TIMESTAMP";
            private static string LEVEL_PLAYED = "LEVEL_PLAYED";
            private static string LEVEL_WON = "LEVEL_WON";

            private int[] interstitialsWatchedMilestones = new int[] { 10, 15, 20 };
            private int[] rewardedsWatchedMilestones = new int[] { 2, 5, 7 };
            private int[] levelPlayedMilestones = new int[] { 1, 5, 10, 20, 50 };
            private int[] _levelsReachedMilestones = new int[] { 3, 5, 7, 10, 15, 20, 25, 30, 40, 50 };


            private void Awake() {
                YCManager.instance.dataManager = this;
                if (this.HasKey(TIMESTAMP) == false) {
                    this.SetInt(TIMESTAMP, this.GetTimestamp());
                }
            }

            public int GetTimestamp() {
                return (int)(DateTimeOffset.Now.ToUnixTimeMilliseconds() / 1000);
            }

            public int GetDiffTimestamp() {
                return this.GetTimestamp() - this.GetInt(TIMESTAMP);
            }

            private void CheckMmpEvent(int value, int[] milestones, string endString) {
                for (int i = 0; i < milestones.Length; i++) {
                    if (value == milestones[i]) {
                        YCManager.instance.mmpManager.SendEvent(value.ToString() + endString);
#if FIREBASE
                        Firebase.Analytics.FirebaseAnalytics.LogEvent("yc_" + value.ToString() + endString);
#endif
                        return;
                    }
                }
            }

            //PLAYER
            public void SetPlayerLaunchCount(int amount) {
                this.SetInt(PLAYER_LAUNCH_COUNT, amount);
            }

            public void IncrementPlayerLaunchCount() {
                this.SetPlayerLaunchCount(this.GetPlayerLaunchCount() + 1);
            }

            public int GetPlayerLaunchCount() {
                return this.GetInt(PLAYER_LAUNCH_COUNT);
            }

            public void SetPlayerGameCount(int amount) {
                this.SetInt(PLAYER_GAME_COUNT, amount);
            }

            public void IncrementPlayerGameCount() {
                this.SetPlayerGameCount(this.GetPlayerGameCount() + 1);
            }

            public int GetPlayerGameCount() {
                return this.GetInt(PLAYER_GAME_COUNT);
            }

            //ADVERTISING ID
            public string GetAdvertisingId() {
                return this.GetString(ADVERTISING_ID, "");
            }
            public void SetAdvertisingId(string id) {
                this.SetString(ADVERTISING_ID, id);
            }
            public bool GetIosConsentFlowShown() {
                return this.GetBool(IOS_CONSENT_SHOWN);
            }
            public void SetIosConsentFlowShown() {
                this.SetBool(IOS_CONSENT_SHOWN, true);
            }

            // ABTEST
            public void SetPlayerSample(string sample) {
                this.SetString(AB_PLAYER_SAMPLE, sample);
            }
            public string GetPlayerSample() {
                return this.GetString(AB_PLAYER_SAMPLE);
            }
            public bool HasPlayerSample() {
                return this.HasKey(AB_PLAYER_SAMPLE);
            }
            public void DeletePlayerSample() {
                this.DeleteKey(AB_PLAYER_SAMPLE);

            }

            // ADS
            public bool GetAdsShow() {
                return this.GetInt(ADSSHOW, 1) == 1;
            }
            public void BuyAdsShow() {
                this.SetInt(ADSSHOW, 0);
            }

            // AdsManager
            public Dictionary<string, double> GetRedRockRevenue() {
                return this.GetObject<Dictionary<string, double>>(REDROCK_REVENUE);
            }

            public void SetRedRockRevenue(Dictionary<string, double> dict) {
                this.SetObject(REDROCK_REVENUE, dict);
            }

            // LANGUAGE
            public void SetLanguage(string lang) {
                this.SetString(LANGUAGE, lang);
            }
            public string GetLanguage() {
                return this.GetString(LANGUAGE, "EN");
            }
            public bool HasLanguage() {
                return this.HasKey(LANGUAGE);
            }

            // GDPR
            public void SetGdprAds(bool consent) {
                this.SetBool(GDPR_ADS, consent);
            }
            public bool GetGdprAds() {
                return this.GetBool(GDPR_ADS, true);
            }

            public void SetGdprAnalytics(bool analytics) {
                this.SetBool(GDPR_ANALYTICS, analytics);
            }
            public bool GetGdprAnalytics() {
                return this.GetBool(GDPR_ANALYTICS, true);
            }

            // NB INTERSTITIALS
            public int GetInterstitialsNb() {
                return this.GetInt(INTERSTITIALS_NB, 0);
            }
            public void IncrementInterstitialsNb() {
                int newValue = this.GetInterstitialsNb() + 1;
                this.SetInt(INTERSTITIALS_NB, newValue);
                this.CheckMmpEvent(newValue, this.interstitialsWatchedMilestones, "_interstitials_watched");
            }

            // NB REWARDEDS
            public int GetRewardedsNb() {
                return this.GetInt(REWARDEDS_NB, 0);
            }
            public void IncrementRewardedsNb() {
                int newValue = this.GetRewardedsNb() + 1;
                this.SetInt(REWARDEDS_NB, newValue);
                this.CheckMmpEvent(newValue, this.rewardedsWatchedMilestones, "_rewardeds_watched");
            }

            // LEVEL PLAYED
            public int GetLevelPlayed() {
                return this.GetInt(LEVEL_PLAYED, 0);
            }

            public int GetLevelWon() {
                return this.GetInt(LEVEL_WON, 0);
            }

            public void IncrementLevelPlayed(bool win) {
                int newValue = this.GetLevelPlayed() + 1;
                this.SetInt(LEVEL_PLAYED, newValue);
                this.CheckMmpEvent(newValue, this.levelPlayedMilestones, "_level_played");

                if (win) {
                    int newWinValue = this.GetLevelWon() + 1;
                    this.SetInt(LEVEL_WON, newWinValue);
                    this.CheckMmpEvent(newWinValue, this._levelsReachedMilestones, "_level_reached");
                }

#if FIREBASE
                Firebase.Analytics.FirebaseAnalytics.LogEvent("yc_level_finished");
#endif
            }

        }
    }
}
