import { module, test } from 'qunit';
import { setupTest } from 'ember-qunit';
import { click, visit } from '@ember/test-helpers';
import find from '@ember/test-helpers/dom/find';

module('Unit | Controller | staff', function(hooks) {
  setupTest(hooks);

  test('closing form resets fields', async function(assert)
  {
    await visit('/staff');

    await click('button.button'); // opens form

    find('#name-field')!.textContent = "testUser";
    find('#username-field')!.textContent = "user2";

    await click('#cancel-button button.button'); // closes form

    await click('button.button'); // reopens form

    assert.equal(find('#name-field')!.textContent, "");
    assert.equal(find('#username-field')!.textContent, "");
  });
});
