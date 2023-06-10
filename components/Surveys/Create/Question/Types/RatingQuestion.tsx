import {
  Box,
  Slider,
  SliderFilledTrack,
  SliderMark,
  SliderThumb,
  SliderTrack,
} from '@chakra-ui/react';

const RatingQuestion = () => {
  return (
    <Slider
      isDisabled
      min={0}
      max={5}
      step={1}
    >
      {Array(5).map((value) => (
        <SliderMark
          key={value}
          value={value}
          mt='1'
          fontSize='sm'
        >
          {value}
        </SliderMark>
      ))}
      <SliderTrack>
        <Box
          position='relative'
          right={10}
        />
        <SliderFilledTrack />
      </SliderTrack>
      <SliderThumb boxSize={6} />
    </Slider>
  );
};

export { RatingQuestion };
