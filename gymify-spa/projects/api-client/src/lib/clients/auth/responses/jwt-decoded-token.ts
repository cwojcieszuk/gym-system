import { JwtPayload } from 'jwt-decode';

export enum JwtClaimTypes {
  NAME_IDENTIFIER = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier',
  NAME = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name',
  EMAIL = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress',
  ROLE = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
}

export interface JwtDecodedToken extends JwtPayload {
  [JwtClaimTypes.NAME_IDENTIFIER]: string;
  [JwtClaimTypes.NAME]: string;
  [JwtClaimTypes.EMAIL]: string;
  [JwtClaimTypes.ROLE]: string;
}
