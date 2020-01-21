import {NgModule} from '@angular/core';
import {ConnectionService} from './connection-service.service';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  imports: [HttpClientModule],
  providers: [ConnectionService]
})
export class ConnectionServiceModule {
}
