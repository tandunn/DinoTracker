import Service from "@ember/service";
import { inject as service } from '@ember/service';

export default class Authentication extends Service {
  @service apollo: any;

  isLoggedIn = false;
  username = "";
}

// DO NOT DELETE: this is how TypeScript knows how to look up your services.
declare module '@ember/service' {
  interface Registry {
    'authentication': Authentication;
  }
}