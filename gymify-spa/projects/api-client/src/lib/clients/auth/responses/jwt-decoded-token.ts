import { JwtPayload } from 'jwt-decode';

export interface JwtDecodedToken extends JwtPayload {
  nameId: number;
  name: string;
  email: string;
}
