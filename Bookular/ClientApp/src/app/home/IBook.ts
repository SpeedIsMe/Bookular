import { IAuthor } from './IAuthor';

export interface IBook {
  id: number;
  title: string;
  description: string;
  authorId: number;
  author: IAuthor;
}
