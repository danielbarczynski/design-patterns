import FancyLogger from "./FancyLogger.js";

const logger = new FancyLogger();

export default function log() {
    logger.log('first source file')
    logger.logCount();
}