import resolve from 'rollup-plugin-node-resolve';
import common from 'rollup-plugin-commonjs';

export default {
    input: 'build/main2.js',
    output: {
        file: 'src/main2.js',
        format: 'esm'
    },
    plugins: [
        common(),
        resolve()
    ]
};
