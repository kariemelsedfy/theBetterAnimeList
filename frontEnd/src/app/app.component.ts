import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `<h1>Token handled!</h1>`,
})
export class AppComponent {
  constructor() {
    const params = new URLSearchParams(window.location.search);
    const token = params.get('access_token');

    if (token) {
      sessionStorage.setItem('mal_token', token);
      console.log('Token stored in sessionStorage:', token);
      //make getUserListCall
      
    } else {
      console.log('No token found in URL');
    }
  }
}
