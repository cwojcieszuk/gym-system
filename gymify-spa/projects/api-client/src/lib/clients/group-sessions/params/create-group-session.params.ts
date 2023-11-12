export interface CreateGroupSessionParams {
  sessionName: string;
  slots: number;
  sessionStartDate: Date;
  sessionEndDate: Date;
  description: string;
  placeId: number;
}
