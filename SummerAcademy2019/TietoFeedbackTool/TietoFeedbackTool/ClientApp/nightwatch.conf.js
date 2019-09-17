var settings = {
  "src_folders": ["NightwatchTests/tests"],
  "page_objects_path": [
    "./NightwatchTests/pageObjects/",
    "./NightwatchTests/pageObjects/tietoFeedbackTool/"
  ],
  "webdriver": {
    "start_process": true,
    "server_path": "./node_modules/chromedriver/lib/chromedriver/chromedriver.exe",
    "port": 9515
  },

  "test_settings": {
    "default": {
      "desiredCapabilities": {
        "browserName": "chrome"
      },
      "launch_url": "add_url"
    },
    "local": {
      "desiredCapabilities": {
        "browserName": "chrome"
      },
      "launch_url": "https://localhost:44350"
    }
  }
};

module.exports = (function (settings) {
  settings.test_workers = false;
  return settings;
})(settings);