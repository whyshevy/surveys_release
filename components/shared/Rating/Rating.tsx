import { ReactNode } from 'react';
import { StarIcon } from '@chakra-ui/icons';

interface RatingProps {
  range: number;
  icon?: ReactNode;
}

const Rating = (props: RatingProps) => {

  return (
    <div>{Array.from({length: props.range}).map((_, i) => <StarIcon key={`star.${i}`} />)}</div>
  )
}

export { Rating };
