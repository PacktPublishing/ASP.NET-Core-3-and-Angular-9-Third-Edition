import { Component } from '@angular/core';
import { ConnectionService } from '../ng-connection-service/connection-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  hasNetworkConnection: boolean;
  hasInternetAccess: boolean;
  isConnected: boolean;
  status: string;

  constructor(private connectionService: ConnectionService) {
    this.connectionService.updateOptions({
      heartbeatUrl: "/isOnline.txt"
    });
    this.connectionService.monitor().subscribe(currentState => {
      this.hasNetworkConnection = currentState.hasNetworkConnection;
      this.hasInternetAccess = currentState.hasInternetAccess;
      if (this.hasNetworkConnection && this.hasInternetAccess) {
        this.isConnected = true;
        this.status = 'ONLINE';
      }
      else {
        this.isConnected = false;
        this.status = 'OFFLINE';
      }
    });
  }
}
