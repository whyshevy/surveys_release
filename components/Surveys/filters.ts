import { UserSurvey } from 'models/surveys/UserSurvey';

export const filterByTitle = (surveys: UserSurvey[], search: string) =>
  surveys.filter((s) => s.title.toLowerCase().includes(search.toLowerCase()));
