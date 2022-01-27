export class Chat {
  public ChatId?: number;
  public Date: Date;
  public Message: string;
  public UserId: number;
  public RoomId: number;
  public Type: string;

  constructor() {
    this.ChatId = 0;
    this.Date = new Date();
    this.Message = '';
    this.UserId = 0;
    this.RoomId = 0;
    this.Type = '';
  }
}
