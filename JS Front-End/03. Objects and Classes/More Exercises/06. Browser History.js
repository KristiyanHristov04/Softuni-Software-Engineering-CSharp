function solve(browserData, actions) {
    let browserName = browserData['Browser Name'];
    let openTabs = browserData['Open Tabs'];
    let recentlyClosed = browserData['Recently Closed'];
    let browserLogs = browserData['Browser Logs'];

    for (let i = 0; i < actions.length; i++) {
        let actionSplitted = actions[i].split(' ');
        let action = actionSplitted.shift();
        let tab = actionSplitted.join(' ');
        let currentBrowserLog = actions[i];
        
        if (action === 'Open') {
            openTabs.push(tab);
            browserLogs.push(currentBrowserLog);
            
        } else if (action == 'Close') {
            let openTabIndex = openTabs.indexOf(tab);
            if (openTabIndex !== - 1) {
                openTabs.splice(openTabIndex, 1);
                recentlyClosed.push(tab);
                browserLogs.push(currentBrowserLog);
            }
        } else {
            openTabs = [];
            recentlyClosed = [];
            browserLogs = [];
        }
    }

    console.log(browserName);
    let openedTabsString = openTabs.join(', ');
    console.log(`Open Tabs: ${openedTabsString}`);
    let recentlyClosedTabsString = recentlyClosed.join(', ');
    console.log(`Recently Closed: ${recentlyClosedTabsString}`);
    let browserLogsString = browserLogs.join(', ');
    console.log(`Browser Logs: ${browserLogsString}`);
}

solve({"Browser Name":"Google Chrome","Open Tabs":["Facebook","YouTube","Google Translate"], "Recently Closed":["Yahoo","Gmail"],
       "Browser Logs":["Open YouTube","Open Yahoo","Open Google Translate","Close Yahoo","Open Gmail","Close Gmail","Open Facebook"]},
       ["Close Facebook", "Open StackOverFlow", "Open Google"],
);