import { module, test } from 'qunit';
import { setupTest } from 'ember-qunit';
import { click, currentURL, visit } from '@ember/test-helpers';
import Service from '@ember/service';

class MockApolloRepositoryService extends Service
{
  login(variables: { username: string, password: string })
  {
    return variables.username == "user1" && variables.password == "1234";
  }
}

module('Unit | Controller | login', function(hooks) {
  setupTest(hooks);

  test('home button redirects to home page', async function(assert) {
    await visit('/login');

    await click('.button a.link');

    assert.equal(currentURL(), '/');
  });

  test('successful login redirects to staff page', async function(assert) {
    this.owner.register('service:apolloRepository', MockApolloRepositoryService);
    let controller = this.owner.lookup('controller:login');

    await visit('/login');

    controller.username = "user1";
    controller.password = "1234";

    await click('.login-button-container button.button');

    assert.equal(controller.isDisplayingErrorMessage, false);
    assert.equal(currentURL(), '/staff');
  });
});
