import Controller from "@ember/controller";
import { tracked } from "@glimmer/tracking";
import { action } from '@ember/object';
import { inject as service } from "@ember/service";
import mutation from "dino-tracker/graphql/mutations/login.graphql";

export default class LoginController extends Controller {
  @service apollo: any;
  @service router: any;

  @tracked username = '';
  @tracked password = '';
  @tracked isDisplayingErrorMessage = false;

  @action
  authenticate() {
    let variables = { username: this.username, password: this.password };
    this.get('apollo').mutate({ mutation, variables }, "login")
      .then((response: any) => {
        if (response == true)
          this.router.transitionTo("staff");
        else
          this.isDisplayingErrorMessage = true;
      })
      .catch(() => this.isDisplayingErrorMessage = true);
  }
}

// DO NOT DELETE: this is how TypeScript knows how to look up your controllers.
declare module "@ember/controller" {
  interface Registry {
    login: LoginController;
  }
}