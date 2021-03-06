import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { AddRoomComponent } from './add-room/add-room.component';
import { ChatRoomComponent } from './chat-room/chat-room.component';
import { ListRoomComponent } from './list-room/list-room.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'listroom', component: ListRoomComponent },
  { path: 'addroom', component: AddRoomComponent },
  { path: 'chatroom/:roomId', component: ChatRoomComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' }  
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
  static components = [
    LoginComponent,
    ListRoomComponent,
    AddRoomComponent,
    ChatRoomComponent
  ]
}
