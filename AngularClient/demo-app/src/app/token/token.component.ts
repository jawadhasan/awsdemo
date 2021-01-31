import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-token',
  templateUrl: './token.component.html',
  styleUrls: ['./token.component.css']
})
export class TokenComponent implements OnInit {

  result:any={};
  constructor( public apiService: ApiService,) { }

 
  ngOnInit(): void {

        this.refreshToken();
  }

  refreshToken(){
    //get data from server
    this.apiService.getToken().subscribe((res: any)=>{

      this.result = res;
 
     });
  }

}
