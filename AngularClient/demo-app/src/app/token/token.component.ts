import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-token',
  templateUrl: './token.component.html',
  styleUrls: ['./token.component.css']
})
export class TokenComponent implements OnInit {

  result:any={};
  envResult:any={};
  constructor( public apiService: ApiService,) { }

 
  ngOnInit(): void {

        this.refreshToken();
        this.getEnv();
  }

  refreshToken(){
    //get data from server
    this.apiService.getToken().subscribe((res: any)=>{

      this.result = res;
 
     });
  }

  getEnv(){
    //get data from server
    this.apiService.getEnv().subscribe((res: any)=>{

      this.envResult = res;
 
     });
  }

}
