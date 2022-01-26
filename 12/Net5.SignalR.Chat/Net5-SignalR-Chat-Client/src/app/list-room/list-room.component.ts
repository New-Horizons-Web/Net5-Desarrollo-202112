import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../services/data.service';
import { Room } from '../models/room';
import { SignalRService } from '../services/signal-r.service';
import { Chat } from '../models/chat';
import { User } from '../models/user';

@Component({
  selector: 'app-roomlist',
  templateUrl: './list-room.component.html',
  styleUrls: ['./list-room.component.scss']
})
export class ListRoomComponent implements OnInit {

  user: User = new User();
  displayedColumns: string[] = ['RoomName'];
  rooms: Room[] = [];
  isLoadingResults = true;
    
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService,
    private signalRService: SignalRService    
  ) {
    let userSAChat = sessionStorage.getItem('userSAChat')!;
    this.user = JSON.parse(userSAChat);
    this.subscribeToEvents();
  }

  ngOnInit(): void {
    this.listRooms();
  }

  private subscribeToEvents(): void {
    this.signalRService.onListRooms.subscribe(() => {
      this.listRooms();
    });
  }

  listRooms() {
    this.isLoadingResults = true;
    this.dataService.listRooms().subscribe(rooms => {
      this.rooms = rooms;
      this.isLoadingResults = false;
    });
  }

  enterChatRoom(roomId: number) {
    this.dataService.getRoomUserByRoomIdAndUserId(roomId, this.user.UserId!).subscribe((roomUser) => {
      if (roomUser) {
        roomUser.Status = 'online';
        this.dataService.updateRoomUser(roomUser).subscribe(() => {
          this.goToChatRoom(roomId);
        })
      } else {
        roomUser = {
          RoomId: roomId,
          UserId: this.user.UserId!,
          Status: 'online'
        };
        this.dataService.insertRoomUser(roomUser).subscribe(() => {
          this.goToChatRoom(roomId);
        });
      }
    });
  }

  goToChatRoom(roomId: number) {
    const chat = new Chat();
    chat.RoomId = roomId;
    chat.UserId = this.user.UserId!;
    chat.Date = new Date();
    chat.Message = `${this.user.UserName} enter the room`;
    chat.Type = 'join';

    /*comment*/
    this.router.navigate(['/chatroom', roomId]);
    /*
    this.signalRService.SendChat(chat).then(() => {
      this.dataService.insertChat(chat).subscribe(() => {
        this.router.navigate(['/chatroom', roomId]);
      });
    });
    */
  }

  logout(): void {
    sessionStorage.removeItem('userSAChat');
    this.router.navigate(['/login']);
  }
}
