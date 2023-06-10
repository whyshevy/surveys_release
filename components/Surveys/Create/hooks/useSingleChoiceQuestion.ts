import { contentField } from '../fields';


const useSingleChoiceQuestion = (optionsFieldName: string) => {
  const getOptionContentFieldName = (index: number) => `${optionsFieldName}.${index}.${contentField}`;

  return { getOptionContentFieldName };
}

export { useSingleChoiceQuestion };
