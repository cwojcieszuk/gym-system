import { DecodedUserData } from './decoded-user-data';
import jwtDecode from 'jwt-decode';
import { JwtClaimTypes, JwtDecodedToken } from './jwt-decoded-token';

export class AccessTokenResponse {
  accessToken: string;
  user: DecodedUserData;

  constructor(accessToken: string) {
    this.accessToken = accessToken;
    const decoded = jwtDecode<JwtDecodedToken>(accessToken);

    this.user = {
      userUid: decoded[JwtClaimTypes.NAME_IDENTIFIER],
      name: decoded[JwtClaimTypes.NAME],
      email: decoded[JwtClaimTypes.EMAIL],
      exp: decoded.exp,
      role: decoded[JwtClaimTypes.ROLE],
    };
  }
}
