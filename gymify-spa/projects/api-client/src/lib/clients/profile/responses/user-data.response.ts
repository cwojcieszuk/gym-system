export interface UserDataResponse {
  firstName: string;
  lastName: string;
  email: string;
  login: string;
  birthDate: Date;
  avatar: any;
  description?: string;
  categoryId: number[];
}
