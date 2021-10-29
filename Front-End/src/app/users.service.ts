import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { API_PATH } from 'src/environments/environment';
import { IUser, IUserId } from './IUsers';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor( private httpClient: HttpClient) { }

  getUser(){
    return this.httpClient.get<IUser[]>(`${API_PATH}v1/Users`).toPromise();
  }

  getUserById(userId: string)
  {
    return this.httpClient.get<IUser>(`${API_PATH}v1/Users/${userId}`).toPromise();
  }

  postUser(user: IUser)
  { 
    return this.httpClient.post<IUser>(`${API_PATH}v1/Users`,user).toPromise();
  }

  putUser(user: IUserId)
  {
    return this.httpClient.post<IUser>(`${API_PATH}v1/Users/${user.id}`,user).toPromise();
  }

  deleteUser(userId: string){
    return this.httpClient.delete(`${API_PATH}v1/Users/${userId}`).toPromise();
  }
}
