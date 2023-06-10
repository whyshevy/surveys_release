import { QuestionProps } from './QuestionProps';
import { Box, Slider, SliderFilledTrack, SliderMark, SliderThumb, SliderTrack, Text } from '@chakra-ui/react';
import { useField } from 'formik';


const RatingQuestion = ({ question, name }: QuestionProps) => {
  const [, , { setValue }] = useField(`${name}.rating`);

  return (
    <Box w='full'>
      <Text fontSize='3xl'>{question.order + 1}. {question.title}</Text>
      <Slider onChange={setValue} defaultValue={0} min={1} max={5} step={1}>
        {
          Array.from({ length: 5 }, (_, i) => i + 1).map((v) => (
            <SliderMark key={v} value={v} mt={2.5} fontSize='md'>
              {v}
            </SliderMark>
          ))
        }
        <SliderTrack>
          <Box position='relative' right={10} />
          <SliderFilledTrack />
        </SliderTrack>
        <SliderThumb boxSize={5} />
      </Slider>
    </Box>
  );
};

export { RatingQuestion };
