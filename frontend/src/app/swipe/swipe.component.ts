import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-swipe',
  templateUrl: './swipe.component.html',
  styleUrl: './swipe.component.css'
})
export class SwipeComponent implements OnInit {
  constructor(private http: HttpClient) {}

  ngOnInit() {
    const MAL_ACCESS_TOKEN = localStorage.getItem('access_token');
    this.http.post<any>('http://localhost:3000/api/getSuggestedAnimes', { MAL_ACCESS_TOKEN: MAL_ACCESS_TOKEN })
      .subscribe({
        next: (result) => {
          console.log('Suggested animes:', result);
        },
        error: (err) => {
          console.error('Error fetching suggested animes:', err);
        }
      });
  }
}
