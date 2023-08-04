import { AccessTokenResponse } from './access-token.response';

export class LoginResponse extends AccessTokenResponse {
  refreshToken: string;

  constructor({ accessToken, refreshToken }: LoginResponse) {
    super(accessToken);
    this.refreshToken = refreshToken;
  }
}
