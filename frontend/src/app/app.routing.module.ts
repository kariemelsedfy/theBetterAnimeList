import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { OauthCallbackComponent } from './oauth-callback/oauth-callback.component';
import { AnimeProfileComponent } from './anime-profile-form-component/anime-profile-form-component.component';
import { SwipeComponent } from './swipe/swipe.component';
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'oauth-callback', component: OauthCallbackComponent },
  { path: 'suggestion-builder-form', component: AnimeProfileComponent},
  { path: 'swipe', component: SwipeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }