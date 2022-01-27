export class RoomUser {
  public RoomUserId?: number;
  public RoomId: number;
  public UserId: number;
  public Status: string;

  constructor() {
    this.RoomUserId = 0;
    this.RoomId = 0;
    this.UserId = 0;
    this.Status = '';
  }
}
