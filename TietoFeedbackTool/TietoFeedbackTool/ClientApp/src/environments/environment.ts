// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  newQuestionUrl: 'http://10.33.0.54:8083/api/survey/questions',
  openAnswerUrl: 'http://10.33.0.54:8083/api/answer/open',
  dataByLoginUrl: 'http://10.33.0.54:8083/api/survey/surveywithq/Jon',
  surveyUrl: 'http://10.33.0.54:8083/api/survey',
  production: false
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
