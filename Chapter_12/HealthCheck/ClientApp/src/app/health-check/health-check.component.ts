import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-health-check',
    templateUrl: './health-check.component.html',
    styleUrls: ['./health-check.component.css']
})
export class HealthCheckComponent {
  public result: Result;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit() {
    this.http.get<Result>(this.baseUrl + 'hc').subscribe(result => {
      this.result = result;
    }, error => console.error(error));
  }
}

interface Result {
    checks: Check[];
    totalStatus: string;
    totalResponseTime: number;
}

interface Check {
    name: string;
    status: string;
    responseTime: number;
}

