// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  newQuestionUrl: 'https://localhost:44350/api/Survey/questions',
  updateQuestionUrl: 'https://localhost:44350/api/Survey/questions',
  openAnswerUrl: 'https://localhost:44350/api/answer/open',
  dataByLoginUrl: 'https://localhost:44350/api/account/OlejWoj',
  accountUrl: 'https://localhost:44350/api/account',
  deleteQuestionUrl: 'https://localhost:44350/api/Survey/questions',
  updateQuestionEnabledUrl: 'https://localhost:44350/api/Survey/Questions/enable',
  newPageUrl: 'https://localhost:44350/api/Survey/Page',
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
