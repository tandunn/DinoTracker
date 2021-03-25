import Controller from "@ember/controller";
import { tracked } from "@glimmer/tracking";
import { action } from '@ember/object';

export default class LoginController extends Controller {
    @tracked username = '';
    @tracked password = '';

    @action
    authenticate()
    {
        alert(this.username + " " + this.password);
    }
}

// DO NOT DELETE: this is how TypeScript knows how to look up your controllers.
declare module "@ember/controller" {
  interface Registry {
    login: LoginController;
  }
}