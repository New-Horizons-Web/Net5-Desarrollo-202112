import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from '../models/user';
import { Room } from '../models/room';
import { Observable } from 'rxjs';
import { Chat } from '../models/chat';
import { RoomUser } from '../models/room-user';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  constructor(private httpClient: HttpClient) { }

  public getUserByUserName(userName: string): Observable<User> {
    return new Observable<User>((observer) => {
      let user: User = {
        UserId: 1,
        UserName:'Erick'
      };
      observer.next(user);
      observer.complete();
    });
  }
  public listUsersByRoomIdAndStatus(roomId: number, status: string): Observable<User[]> {
    return new Observable<User[]>((observer) => {
      let users: User[] = [{
        UserId: 1,
        UserName: 'Erick'
      }];
      observer.next(users);
      observer.complete();
    });

    /*
    let params = new HttpParams();
    params = params.append('roomId', roomId.toString());
    params = params.append('status', status);
    return this.httpClient.get<User[]>(`${this.usersURL}/`, { params: params });
    */
  }
  public listUsersByRoomIdAndUserIdAndStatus(roomId: number, userId: number, status: string): Observable<User[]> {
    return new Observable<User[]>((observer) => {
      let users: User[] = [{
        UserId: 1,
        UserName: 'Erick'
      }];
      observer.next(users);
      observer.complete();
    });
    /*
    let params = new HttpParams();
    params = params.append('roomId', roomId.toString());
    params = params.append('userId', userId.toString());
    params = params.append('status', status);
    return this.httpClient.get<User[]>(`${this.usersURL}/`, { params: params });
    */
  }
  public listUsersByRoomId(roomId: number): Observable<User[]> {
    return new Observable<User[]>((observer) => {
      let users: User[] = [{
        UserId: 1,
        UserName: 'Erick'
      }];
      observer.next(users);
      observer.complete();
    });
    /*
    let params = new HttpParams();
    params = params.append('roomId', roomId.toString());
    return this.httpClient.get<User[]>(`${this.usersURL}/`, { params: params });
    */
  }
  public insertUser(user: User): Observable<User> {
    return new Observable<User>((observer) => {
      let user: User = {
        UserId: 1,
        UserName: 'Erick'
      };
      observer.next(user);
      observer.complete();
    });
    //return this.httpClient.post<User>(`${this.usersURL}/`, user);
  }

  public getRoomByRoomId(roomId: number): Observable<Room> {
    return new Observable<Room>((observer) => {
      let room: Room = {
        RoomId: 1,
        RoomName:'Net'
      };
      observer.next(room);
      observer.complete();
    });
    //return this.httpClient.get<Room>(`${this.roomsURL}/` + roomId);
  }
  public getRoomByRoomName(roomName: string): Observable<Room> {
    return new Observable<Room>((observer) => {
      let room: Room = {
        RoomId: 1,
        RoomName: 'Net'
      };
      observer.next(room);
      observer.complete();
    });
    /*
    let params = new HttpParams();
    params = params.append('roomName', roomName);
    return this.httpClient.get<Room>(`${this.roomsURL}/`, { params: params });
    */
  }
  public listRooms(): Observable<Room[]> {
    return new Observable<Room[]>((observer) => {
      let rooms: Room[] = [{
        RoomId: 1,
        RoomName: 'Net'
      }];
      observer.next(rooms);
      observer.complete();
    });
    //return this.httpClient.get<Room[]>(`${this.roomsURL}/`);
  }
  public insertRoom(room: Room): Observable<Room> {
    return new Observable<Room>((observer) => {
      let room: Room = {
        RoomId: 1,
        RoomName: 'Net'
      };
      observer.next(room);
      observer.complete();
    });
    //return this.httpClient.post<Room>(`${this.roomsURL}/`, room);
  }

  public listChatsByRoomId(roomId: number): Observable<Chat[]> {
    return new Observable<Chat[]>((observer) => {
      let chats: Chat[] = [{
        RoomId: 1,
        Date: new Date(),
        Message: 'Test',
        Type: 'Tipo test',
        UserId: 1,
        ChatId:1
      }];
      observer.next(chats);
      observer.complete();
    });
    /*
    let params = new HttpParams();
    params = params.append('roomId', roomId.toString());
    return this.httpClient.get<Chat[]>(`${this.chatsURL}/`, { params: params });
    */
  }
  public insertChat(chat: Chat): Observable<Chat> {
    return new Observable<Chat>((observer) => {
      let chat: Chat = {
        RoomId: 1,
        Date: new Date(),
        Message: 'Test',
        Type: 'Tipo test',
        UserId: 1,
        ChatId: 1
      };
      observer.next(chat);
      observer.complete();
    });
    //return this.httpClient.post<Chat>(`${this.chatsURL}/`, chat);
  }

  public getRoomUserByRoomIdAndUserId(roomId: number, userId: number): Observable<RoomUser> {
    return new Observable<RoomUser>((observer) => {
      let roomUser: RoomUser = {
        RoomId: 1,
        Status: 'online',
        UserId: 1,
        RoomUserId:1
      };
      observer.next(roomUser);
      observer.complete();
    });
    /*
    let params = new HttpParams();
    params = params.append('roomId', roomId.toString());
    params = params.append('userId', userId.toString());
    return this.httpClient.get<RoomUser>(`${this.roomUsersURL}/`, { params: params });
    */
  }
  public insertRoomUser(roomUser: RoomUser): Observable<RoomUser> {
    return new Observable<RoomUser>((observer) => {
      let roomUser: RoomUser = {
        RoomId: 1,
        Status: 'On-line',
        UserId: 1,
        RoomUserId: 1
      };
      observer.next(roomUser);
      observer.complete();
    });
    //return this.httpClient.post<RoomUser>(`${this.roomUsersURL}/`, roomUser);
  }
  public updateRoomUser(roomUser: RoomUser): Observable<RoomUser> {
    return new Observable<RoomUser>((observer) => {
      let roomUser: RoomUser = {
        RoomId: 1,
        Status: 'On-line',
        UserId: 1,
        RoomUserId: 1
      };
      observer.next(roomUser);
      observer.complete();
    });
    //return this.httpClient.put<RoomUser>(`${this.roomUsersURL}/`, roomUser);
  }

}
