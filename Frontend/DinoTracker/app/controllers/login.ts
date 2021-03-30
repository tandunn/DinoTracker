import Controller from "@ember/controller";
import { tracked } from "@glimmer/tracking";
import { action } from '@ember/object';
import { inject as service } from "@ember/service";
import ApolloRepository from "dino-tracker/services/apollo-repository";

export default class LoginController extends Controller {
  @service router: any;
  @service apolloRepository!: ApolloRepository;

  @tracked username = '';
  @tracked password = '';
  @tracked isDisplayingErrorMessage = false;

  @action
  async authenticate()
  {
    let variables = { username: this.username, password: this.password };
    let response: boolean;

    try
    {
      response = await this.get('apolloRepository').login(variables);
      if (response == true)
        this.router.transitionTo("staff");
      else
        this.isDisplayingErrorMessage = true;
    }
    catch
    {
      this.isDisplayingErrorMessage = true;
    }
  }
}

// DO NOT DELETE: this is how TypeScript knows how to look up your controllers.
declare module "@ember/controller" {
  interface Registry {
    login: LoginController;
  }
}