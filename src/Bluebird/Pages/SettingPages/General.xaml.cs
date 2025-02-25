﻿using Bluebird.Core;
using Windows.UI.Xaml.Controls;

namespace Bluebird.Pages.SettingPages;

public sealed partial class General : Page
{
    public General()
    {
        this.InitializeComponent();
        SearchengineSelection.Loaded += SearchengineSelection_Loaded;
        SearchengineSelection.SelectionChanged += SearchengineSelection_SelectionChanged;
    }

    private void SearchengineSelection_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        string selection = SettingsHelper.GetSetting("EngineFriendlyName");
        if (selection != null)
            SearchengineSelection.PlaceholderText = selection;
        else
            SearchengineSelection.PlaceholderText = "Qwant Lite";
    }

    private void SearchengineSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string selection = e.AddedItems[0].ToString();
        if (selection == "Ask") SetEngine("Ask", "https://www.ask.com/web?q=");
        if (selection == "Baidu") SetEngine("Baidu", "https://www.baidu.com/s?ie=utf-8&f=8&rsv_bp=1&rsv_idx=1&tn=baidu&wd=");
        if (selection == "Bing") SetEngine("Bing", "https://www.bing.com?q=");
        if (selection == "DuckDuckGo") SetEngine("DuckDuckGo", "https://www.duckduckgo.com?q=");
        if (selection == "Ecosia") SetEngine("Ecosia", "https://www.ecosia.org/search?q=");
        if (selection == "Google") SetEngine("Google", "https://www.google.com/search?q=");
        if (selection == "Startpage") SetEngine("Startpage", "https://www.startpage.com/search?q=");
        if (selection == "Qwant") SetEngine("Qwant", "https://www.qwant.com/?q=");
        if (selection == "Qwant Lite") SetEngine("Qwant Lite", "https://lite.qwant.com/?q=");
        if (selection == "Yahoo!") SetEngine("Yahoo!", "https://search.yahoo.com/search?p=");
    }

    private void SetEngine(string EngineFriendlyName, string SearchUrl)
    {
        SettingsHelper.SetSetting("EngineFriendlyName", EngineFriendlyName);
        SettingsHelper.SetSetting("SearchUrl", SearchUrl);
    }
}
