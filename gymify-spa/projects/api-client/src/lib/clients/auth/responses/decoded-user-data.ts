import { JwtDecodedToken } from './jwt-decoded-token';

export interface DecodedUserData {
  userId: number;
  name: string;
  email: string;
  exp: JwtDecodedToken['exp'];
}
