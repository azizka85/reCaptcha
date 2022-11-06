/**
 * Load script by url
 * @param {string} url
 * @param {() => void} callback
 * @returns {HTMLScriptElement}
 */
function loadScript(url, callback) {
    let script = document.createElement('script')

    script.onload = () => callback();    

    script.src = url;

    document.head.appendChild(script);

    return script
}

/**
 * Format url by element values
 * @param {string} url
 * @returns {string}
 */
function formatUrl(url) {
    const pattern = /{([^{}]+)}/g

    let res = pattern.exec(url)

    while (res) {        
        let val = ''

        if (res.length > 1) {
            val = document.getElementById(res[1])?.value            
        }

        url = url.replace(res[0], val)

        res = pattern.exec(url)
    }    

    return url
}