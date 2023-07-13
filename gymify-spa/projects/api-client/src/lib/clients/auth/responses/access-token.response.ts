import { DecodedUserData } from './decoded-user-data';
import jwtDecode from 'jwt-decode';
import { JwtDecodedToken } from './jwt-decoded-token';

export class AccessTokenResponse {
  accessToken: string;
  user: DecodedUserData;

  constructor(accessToken: string) {
    this.accessToken = accessToken;
    const decoded = jwtDecode<JwtDecodedToken>(accessToken);

    this.user = {
      userId: decoded.nameId,
      name: decoded.name,
      email: decoded.email,
      exp: decoded.exp,
    };
  }
}
