import { LocalStorageHelpers } from './local-storage.helpers';
import jwtDecode, { JwtPayload } from 'jwt-decode';
import { DecodedUserData } from '../../../../../api-client/src/lib/clients/auth/responses/decoded-user-data';
import { AccessTokenResponse } from '../../../../../api-client/src/lib/clients/auth/responses/access-token.response';

export class AuthHelpers {
  static getAccessTokenExp(token: string | null): number | null {
    if(!token) {
      return null;
    }

    const exp = this.decodeToken(token).exp;
    return exp ? exp * 1000 : null; //token stores expiry time in seconds instead of miliseconds
  }

  static getRefreshTokenExp(expiresIn: number): number {
    return new Date().setSeconds(new Date().getSeconds() + expiresIn);
  }

  static getUserRoles(token: string | null): string[] {
    if(!token) {
      return [];
    }

    const roles = this.decodeToken(token).role;

    return roles ?? []; //there is a possibility for the token not to contain 'role' field
  }

  static getUserName(token: string | null): string {
    if(!token) {
      return '';
    }

    const name = this.decodeToken(token).unique_name;

    return name ?? '';
  }

  static getUser(token: string | undefined): DecodedUserData | undefined {
    if (!token) {
      return undefined;
    }

    const resp = new AccessTokenResponse(token);

    return resp.user;
  }

  // static getInitialStatus(): AuthStatus {
  //   const token = LocalStorageHelpers.getAccessToken();
  //   const exp = this.getAccessTokenExp(token);
  //
  //   if(exp && exp > Date.now()) {
  //     return AuthStatus.Authenticated;
  //   }
  //   return AuthStatus.LoggedOut;
  // }

  static setLocalStorageValues(values: { accessToken?: string; refreshToken?: string; refreshTokenExpiresIn?: string }): void {
    if(values.accessToken) {
      LocalStorageHelpers.setAccessToken(values.accessToken);
    }

    if(values.refreshToken) {
      LocalStorageHelpers.setRefreshToken(values.refreshToken);
    }

    if(values.refreshTokenExpiresIn) {
      const currentTime = new Date();
      LocalStorageHelpers.setRefreshTokenExp(currentTime.setSeconds(currentTime.getSeconds() + Number(values.refreshTokenExpiresIn)));
    }
  }

  static removeLocalStorageValues(): void {
    LocalStorageHelpers.removeAccessToken();
    LocalStorageHelpers.removeRefreshToken();
    LocalStorageHelpers.removeRefreshTokenExp();
  }

  private static decodeToken(token: string): DecodedToken {
    return jwtDecode<DecodedToken>(token);
  }
}

export interface DecodedToken extends JwtPayload {
  unique_name: string;
  role: string[];
}
