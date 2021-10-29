import { Component } from '@angular/core';
import { IUser, IUserId } from './IUsers';
import { UsersService } from './users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'front-end';

  constructor(private userService: UsersService){}

  getUser()
  {
    this.userService.getUser()
      .then(users => console.log(users))
      .catch(error => console.error(error));
  }

  getUserById()
  {
    this.userService.getUserById("607685a3-4ef2-4fbf-82be-36b2c79adde6")
      .then(user => console.log(user))
      .catch(error => console.log(error));
  }

  postUser()
  {
    const user: IUser = 
    {
      nome: "Jonatas",
      sobreNome: "Sena Diniz",
      email: "jsenadiniz@gmail.com",
      dataNascimento: new Date(1999, 6, 30),
      escolaridade: "Superior",
    }

    this.userService.postUser(user)
      .then(user => console.log(user))
      .catch(error => console.error(error));
  }

  putUser()
  {
    const user: IUserId = 
    {
      id:"607685a3-4ef2-4fbf-82be-36b2c79adde6",
      nome: "Jonatas",
      sobreNome:"Sena Diniz",
      email:"jsenadiniz@gmail.com",
      dataNascimento: new Date(1999,6,30),
      escolaridade:"Superior"
    }

    this.userService.putUser(user)
      .then(user => console.log(user))
      .catch(error => console.error(error));
  }

  deleteUser()
  {
    this.userService.deleteUser("607685a3-4ef2-4fbf-82be-36b2c79adde6")
      .then(res => console.log(res))
      .catch(error => console.error(error));
  }
}
