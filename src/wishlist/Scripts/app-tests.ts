import { getStuff } from "./Test";

describe('get stuff', () => {
	it('returns awesome stuff', () => {
		var result = getStuff();
		
		expect(result).toContain('awesome stuff');
	});
})