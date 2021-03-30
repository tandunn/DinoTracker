import Service from '@ember/service';
import { inject as service } from '@ember/service';
import mutation from "dino-tracker/graphql/mutations/login.graphql";

export default class ApolloRepository extends Service.extend({
  // anything which *must* be merged to prototype here
}) {
  @service apollo: any;

  public async login(variables: { username: string, password: string }): Promise<boolean>
  {
    let response : boolean;
    try
    {
      response = await this.get('apollo').mutate({ mutation, variables }, "login");
      return response;
    }
    catch
    {
      return false;
    }
  }
}

// DO NOT DELETE: this is how TypeScript knows how to look up your services.
declare module '@ember/service' {
  interface Registry {
    'apollo-repository': ApolloRepository;
  }
}
