import { JwtClaimTypes, JwtDecodedToken } from './jwt-decoded-token';

export interface DecodedUserData {
  userUid: JwtDecodedToken[JwtClaimTypes.NAME_IDENTIFIER];
  name: JwtDecodedToken[JwtClaimTypes.NAME];
  email: JwtDecodedToken[JwtClaimTypes.EMAIL];
  exp: JwtDecodedToken['exp'];
  role: JwtDecodedToken[JwtClaimTypes.ROLE];
}
