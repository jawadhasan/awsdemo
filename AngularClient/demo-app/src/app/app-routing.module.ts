import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TokenComponent } from './token/token.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  { path: 'users', component: UsersComponent },
  { path: 'token', component: TokenComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
