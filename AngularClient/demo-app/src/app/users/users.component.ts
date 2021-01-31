import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users:any;
  constructor( public apiService: ApiService,) { }

 
  ngOnInit(): void {

        //get data from server
        this.apiService.getUsers().subscribe((res: any)=>{

         this.users = res;
    
        });
  }


  delete(id:any) {
    
    this.apiService.deleteUser(id)
      .subscribe((result: any) => {
         alert(`Deleted id: ${id}`);
         location.reload();
        },
        (err: any) => console.log(err));
  }

}
